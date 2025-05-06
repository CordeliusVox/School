local RarityManager = require(script.Parent.RarityManager)

local StarManager = {}
StarManager.__index = StarManager

-- Constructor
function StarManager.new(player: Player, maxStars: number, spawnAreaMin: Vector3, spawnAreaMax: Vector3, minPadding: number)
	local self = setmetatable({}, StarManager)
	self.player = player
	self.maxzStars = maxStars
	self.spawnAreaMin = spawnAreaMin
	self.spawnAreaMax = spawnAreaMax
	self.minPadding = minPadding
	self.starFolder = Instance.new("Folder")
	self.starFolder.Name = "Stars_" .. player.UserId
	self.starFolder.Parent = game.Workspace.Sparks
	self.stars = {}
	self:InitializeStars()
	return self
end

-- Check if a position is valid (respects padding)
function StarManager:IsValidPosition(position: Vector3): boolean
	for _, star in ipairs(self.stars) do
		if (star.Position - position).Magnitude < self.minPadding then
			return false
		end
	end
	return true
end

-- Spawn a single star with padding
function StarManager:SpawnStar()
	if #self.stars >= self.maxStars then return end
	local rarity = RarityManager:GetRandomRarity()
	local maxAttempts = 10
	local position: Vector3?
	
	for _ = 1, maxAttempts do
		local tryPosition = Vector3.new(
			math.random(self.spawnAreaMin.X, self.spawnAreaMax.X),
			math.random(self.spawnAreaMin.Y, self.spawnAreaMax.Y),
			math.random(self.spawnAreaMin.Z, self.spawnAreaMax.Z)
		)
		if self:IsValidPosition(tryPosition) then
			position = tryPosition
			break
		end
	end
	
	if not position then return end -- Skip if no valid position found
	
	local star = Instance.new("Part")
	star.Name = rarity.name .. "Star"
	star.Size = Vector3.new(1, 1, 1)
	star.Shape = Enum.PartType.Ball
	star.Position = position
	star.Anchored = true
	star.CanCollide = false
	star.Color = rarity.color
	star.Parent = self.starFolder
	
	-- Secure ownership
	local ownerTag = Instance.new("StringValue")
	ownerTag.Name = "OwnerUserId"
	ownerTag.Value = tostring(self.player.UserId)
	ownerTag.Parent = star
	
	table.insert(self.stars, star)
end

-- Initialize all stars
function StarManager:InitializeStars()
	for _ = 1, self.maxStars do
		self:SpawnStar()
	end
end

-- Update: Spawn a new star after delay if below max
function StarManager:Update()
	if #self.stars >= self.maxStars then return end
	task.wait(3) -- Wait 3 seconds
	self:SpawnStar()
end

-- Remove a star
function StarManager:RemoveStar(star: Part)
	for i, s in ipairs(self.stars) do
		if s == star then
			table.remove(self.stars, i)
			star:Destroy()
			self:Update()
			break
		end
	end
end

-- Cleanup
function StarManager:Destroy()
	self.starFolder:Destroy()
	self.stars = {}
end

return StarManager