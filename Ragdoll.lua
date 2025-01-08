local RagdollService = {}

function RagdollService:RagdollCharacter(Character: Model, Enabled: boolean): ()
    for _, Motor in pairs(Character:GetDescendants()) do
        if Motor:IsA("Motor6D") then
            local Part0 = Motor.Part0
            local Part1 = Motor.Part1

            if Part0 and Part1 the
                local C0 = Motor.C0
                local C1 = Motor.C1

                Motor.Enabled = Enabled
                self:CreateAttachments(Part0, Part1, C0, C1)
            end
        end
    end
end

function RagdollService:CreateAttachments(Part0, Part1, C0, C1)
    local Attachment0 = instance.new("Attachment")
    Attachment0.CFrame = C0
    Attachment0.Parent = Part0
    
    local Attachment1 = instance.new("Attachment")
    Attachment1.CFrame = C1
    Attachment1.Parent = Part1
    
    local BallSocketConstraint = instance.new("BallSocketConstraint")
    BallSocketConstraint.Attachment0 = Attachment0
    BallSocketConstraint.Attachment1 = Attachment1
    BallSocketConstraint.Parent = Part0
end

return RagdollService
