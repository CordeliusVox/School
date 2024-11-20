using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "3D Rotating Cube";
        Console.CursorVisible = false;
        Console.ForegroundColor = ConsoleColor.Cyan;

        // Set the console dimensions to improve aesthetics
        Console.WindowHeight = 30;
        Console.WindowWidth = 80;

        RotatingCube();

        Console.ResetColor();
        Console.WriteLine("\nSimulation complete. Press any key to exit...");
        Console.ReadKey();
    }

    static void RotatingCube()
    {
        double angleX = 0, angleY = 0, angleZ = 0; // Rotation angles
        double cubeSize = 10; // Size of the cube
        double distance = 20; // Distance from the camera
        double scale = 2; // Scale factor for the cube
        int screenWidth = 80;
        int screenHeight = 30;

        // Cube vertices (8 corners)
        double[,] vertices = {
            { -1, -1, -1 },
            {  1, -1, -1 },
            {  1,  1, -1 },
            { -1,  1, -1 },
            { -1, -1,  1 },
            {  1, -1,  1 },
            {  1,  1,  1 },
            { -1,  1,  1 }
        };

        // Edges connecting the vertices
        int[,] edges = {
            { 0, 1 }, { 1, 2 }, { 2, 3 }, { 3, 0 }, // Back face
            { 4, 5 }, { 5, 6 }, { 6, 7 }, { 7, 4 }, // Front face
            { 0, 4 }, { 1, 5 }, { 2, 6 }, { 3, 7 }  // Connecting edges
        };

        while (!Console.KeyAvailable) // Run until a key is pressed
        {
            Console.Clear();

            double[,] projectedVertices = new double[8, 2]; // 2D projection

            for (int i = 0; i < 8; i++)
            {
                // Rotate vertices
                double x = vertices[i, 0];
                double y = vertices[i, 1];
                double z = vertices[i, 2];

                // Rotation around X-axis
                double tempY = y * Math.Cos(angleX) - z * Math.Sin(angleX);
                double tempZ = y * Math.Sin(angleX) + z * Math.Cos(angleX);
                y = tempY; z = tempZ;

                // Rotation around Y-axis
                double tempX = x * Math.Cos(angleY) + z * Math.Sin(angleY);
                z = -x * Math.Sin(angleY) + z * Math.Cos(angleY);
                x = tempX;

                // Rotation around Z-axis
                tempX = x * Math.Cos(angleZ) - y * Math.Sin(angleZ);
                y = x * Math.Sin(angleZ) + y * Math.Cos(angleZ);
                x = tempX;

                // Project the 3D point to 2D
                double perspective = distance / (distance + z);
                double screenX = (x * perspective * scale) + screenWidth / 2;
                double screenY = (y * perspective * scale) + screenHeight / 2;

                projectedVertices[i, 0] = screenX;
                projectedVertices[i, 1] = screenY;
            }

            // Draw the edges
            for (int i = 0; i < edges.GetLength(0); i++)
            {
                int start = edges[i, 0];
                int end = edges[i, 1];

                int x1 = (int)projectedVertices[start, 0];
                int y1 = (int)projectedVertices[start, 1];
                int x2 = (int)projectedVertices[end, 0];
                int y2 = (int)projectedVertices[end, 1];

                DrawLine(x1, y1, x2, y2);
            }

            // Increment rotation angles
            angleX += 0.05;
            angleY += 0.03;
            angleZ += 0.02;

            Thread.Sleep(50); // Control the animation speed
        }
    }

    static void DrawLine(int x1, int y1, int x2, int y2)
    {
        int dx = Math.Abs(x2 - x1);
        int dy = Math.Abs(y2 - y1);
        int sx = x1 < x2 ? 1 : -1;
        int sy = y1 < y2 ? 1 : -1;
        int err = dx - dy;

        while (true)
        {
            if (x1 >= 0 && x1 < Console.WindowWidth && y1 >= 0 && y1 < Console.WindowHeight)
            {
                Console.SetCursorPosition(x1, y1);
                Console.Write('*');
            }

            if (x1 == x2 && y1 == y2) break;

            int e2 = 2 * err;
            if (e2 > -dy) { err -= dy; x1 += sx; }
            if (e2 < dx) { err += dx; y1 += sy; }
        }
    }
}