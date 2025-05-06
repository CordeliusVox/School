local Players = game:GetService("Players")
local ReplicatedStorage = game:GetService("ReplicatedStorage")
local TweenService = game:GetService("TweenService")

local player = Players.LocalPlayer
local catchEvent = ReplicatedStorage:WaitForChild("CatchStar")
local starFolder = game.Workspace.Sparks:WaitForChild("Stars_" .. player.UserId)

-- Animate a star
local function animateStar(star: Part)
	local originalPosition = star.Position
	local tweenInfo = TweenInfo.new(
		2, -- Duration
		Enum.EasingStyle.Sine,
		Enum.EasingDirection.InOut,
		-1, -- Infinite
		true -- Reverse
	)
	local tween = TweenService:Create(star, tweenInfo, {Position = originalPosition + Vector3.new(0, 1, 0)})
	tween:Play()
end

-- Handle new stars
starFolder.ChildAdded:Connect(function(star)
	animateStar(star)
end)

-- Animate existing stars
for _, star in ipairs(starFolder:GetChildren()) do
	animateStar(star)
end

-- Catch feedback (placeholder)
catchEvent.OnClientEvent:Connect(function(rarity: string, position: Vector3)
	print("Caught a " .. rarity .. " star at " .. tostring(position))
end)