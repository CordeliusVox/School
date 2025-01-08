local RagdollService = {}

local function CreateAttachments(Part0, Part1, C0, C1) 
	local Attachment0 = Instance.new("Attachment")
	Attachment0.CFrame = C0
	Attachment0.Parent = Part0

	local Attachment1 = Instance.new("Attachment")
	Attachment1.CFrame = C1
	Attachment1.Parent = Part1

	local BallSocketConstraint = Instance.new("BallSocketConstraint")
	BallSocketConstraint.Attachment0 = Attachment0
	BallSocketConstraint.Attachment1 = Attachment1
	BallSocketConstraint.Parent = Part0

	-- Debug
	Attachment0.Visible = true
	Attachment1.Visible = true
end

function RagdollService:RagdollCharacter(Character: Model): ()
	for _, Motor in pairs(Character:GetDescendants()) do
		if Motor:IsA("Motor6D") then
			local Part0 = Motor.Part0
			local Part1 = Motor.Part1

			if Part0 and Part1 then
				local C0 = Motor.C0
				local C1 = Motor.C1

				Motor.Enabled = false
				CreateAttachments(Part0, Part1, C0, C1)
			end
		end
	end
end

function RagdollService:UnragdollCharacter(Character: Model): ()
	for _, Descendant in pairs(Character:GetDescendants()) do
		if Descendant:IsA("BallSocketConstraint") then
			Descendant:Destroy()
		end
		
		if Descendant:IsA("Attachment") and Descendant.Name == "Attachment" then
			Descendant:Destroy()
		end
		
		if Descendant:IsA("Motor6D") then
			Descendant.Enabled = true
		end
	end
end

return RagdollService
