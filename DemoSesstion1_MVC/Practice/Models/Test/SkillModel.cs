namespace Practice.Models.Test;

public class SkillModel
{
    public List<Skill> GetSkill()
    {
        return new List<Skill>()
        {
            new Skill()
            {
                Id = 1,
                Name = "English"
            },
            new Skill()
            {
                Id = 2,
                Name = "Conversation"
            },            
            new Skill()
            {
                Id = 3,
                Name = "Counter-argument"
            },
        };
    }
}
