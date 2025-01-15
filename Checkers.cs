<Window x:Class="Checkers.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:Checkers"
        mc:Ignorable="d"
        Title="Checkers" 
        WindowStyle="SingleBorderWindow"
        MaxHeight="900" MinHeight="900" Height="900"
        MaxWidth="1000" MinWidth="1000" Width="1000">
    <Grid>
        <!-- Background Image -->
        <StackPanel>
            <Image Source="/Images/Wooden Background.jpg" Stretch="Fill"/>
        </StackPanel>
        
        <!-- Checkers Table -->
        <Grid HorizontalAlignment="Center" VerticalAlignment="Center" Width="600" Height="600">
            <UniformGrid Rows="8" Columns="8"  Background="BurlyWood">
                <!-- Squares Grids -->
                <Border Name="b1" Background="Black"/>
                <Border/>
                <Border Name="b2" Background="Black"/>
                <Border/>
                <Border Name="b3" Background="Black"/>
                <Border/>
                <Border Name="b4" Background="Black"/>
                <Border/>

                <Border/>
                <Border Name="b5" Background="Black"/>
                <Border/>
                <Border Name="b6" Background="Black"/>
                <Border/>
                <Border Name="b7" Background="Black"/>
                <Border/>
                <Border Name="b8" Background="Black"/>

                <Border Name="b9" Background="Black"/>
                <Border/>
                <Border Name="b10" Background="Black"/>
                <Border/>
                <Border Name="b11" Background="Black"/>
                <Border/>
                <Border Name="b12" Background="Black"/>
                <Border/>

                <Border/>
                <Border Name="b13" Background="Black"/>
                <Border/>
                <Border Name="b14" Background="Black"/>
                <Border/>
                <Border Name="b15" Background="Black"/>
                <Border/>
                <Border Name="b16" Background="Black"/>

                <Border Name="b17" Background="Black"/>
                <Border/>
                <Border Name="b18" Background="Black"/>
                <Border/>
                <Border Name="b19" Background="Black"/>
                <Border/>
                <Border Name="b20" Background="Black"/>
                <Border/>

                <Border/>
                <Border Name="b21" Background="Black"/>
                <Border/>
                <Border Name="b22" Background="Black"/>
                <Border/>
                <Border Name="b23" Background="Black"/>
                <Border/>
                <Border Name="b24" Background="Black"/>

                <Border Name="b25" Background="Black"/>
                <Border/>
                <Border Name="b26" Background="Black"/>
                <Border/>
                <Border Name="b27" Background="Black"/>
                <Border/>
                <Border Name="b28" Background="Black"/>
                <Border/>

                <Border/>
                <Border Name="b29" Background="Black"/>
                <Border/>
                <Border Name="b30" Background="Black"/>
                <Border/>
                <Border Name="b31" Background="Black"/>
                <Border/>
                <Border Name="b32" Background="Black"/>
            </UniformGrid>
        </Grid>
    </Grid>
</Window>
