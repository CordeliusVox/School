local TweenService = game:GetService("TweenService")
local RarityManager = require(script.Parent.RarityManager)

local StarManager = {}
StarManager.__index = StarManager

function StarManager.new(player, maxStars, spawnAreaMin, spawnAreaMax)
	local self = setmetatable({}, StarManager)
	self.player = player
	self.maxStars = maxStars
	self.spawnAreaMin = spawnAreaMin
	self.spawnAreaMax = spawnAreaMax
	self.starFolder = Instance.new("Folder")
	self.starFolder.Name = "Stars_" .. player.UserId
	self.starFolder.Parent = game.Workspace.Sparks
	self.stars = {}
	self:SpawnStars()
	return self
end

function StarManager:SpawnStar()
	if #self.stars >= self.maxStars then return end
	local rarity = RarityManager.GetRandomRarity()
	local star = Instance.new("Part")
	star.Name = rarity.name .. "Star"
	star.Size = Vector3.new(1, 1, 1)
	star.Shape = Enum.PartType.Ball
	star.Position = Vector3.new(
		math.random(self.spawnAreaMin.X, self.spawnAreaMax.X),
		math.random(self.spawnAreaMin.Y, self.spawnAreaMax.Y),
		math.random(self.spawnAreaMin.Z, self.spawnAreaMax.Z)
	)
	star.Anchored = true
	star.CanCollide = false
	star.Color = rarity.color
	star.Parent = self.starFolder
	
	-- Secure ownership
	local ownerTag = Instance.new("StringValue")
	ownerTag.Name = "OwnerUserId"
	ownerTag.Value = tostring(self.player.UserId)
	ownerTag.Parent = star
	
	-- Visual enhancement
	local particle = Instance.new("ParticleEmitter")
	particle.Texture = "rbxassetid://243098098" -- Sparkle effect
	particle.Rate = 10
	particle.Lifetime = NumberRange.new(1, 2)
	particle.Speed = NumberRange.new(0.5, 1)
	particle.Parent = star
	
	-- Proximity prompt for catching
	local prompt = Instance.new("ProximityPrompt")
	prompt.MaxActivationDistance = 5
	prompt.ActionText = "Catch"
	prompt.Parent = star
	prompt.Triggered:Connect(function(triggerPlayer)
		if triggerPlayer.UserId == self.player.UserId then
			local rarityName = star.Name:gsub("Star", "")
			self:RemoveStar(star)
			game.ReplicatedStorage.CatchStar:FireClient(triggerPlayer, rarityName, star.Position)
		end
	end)
	
	self:AnimateStar(star)
	table.insert(self.stars, star)
end

function StarManager:AnimateStar(star)
	local originalPosition = star.Position
	local tweenInfo = TweenInfo.new(
		2, -- Duration
		Enum.EasingStyle.Sine,
		Enum.EasingDirection.InOut,
		-1, -- Infinite repeats
		true -- Reverse
	)
	local tween = TweenService:Create(star, tweenInfo, {Position = originalPosition + Vector3.new(0, 1, 0)})
	tween:Play()
end

function StarManager:SpawnStars()
	for _ = 1, self.maxStars do
		self:SpawnStar()
	end
end

function StarManager:RemoveStar(star)
	for i, s in ipairs(self.stars) do
		if s == star then
			table.remove(self.stars, i)
			star:Destroy()
			break
		end
	end
	task.wait(3) -- Respawn delay
	self:SpawnStar()
end

return StarManager