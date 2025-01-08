local RagdollService = {}

function RagdollService:ModifyMotor6D(Character: Model, Enabled: boolean): ()
    for _, Motor in pairs(Character:GetDescendants()) do
        if Motor:IsA("Motor6D") then
            Motor.Enabled = Enabled
        end
    end
end
return RagdollService
