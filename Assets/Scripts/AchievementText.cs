using System.Collections.Generic;

public class AchievementInfo
{
    public string Name;
    public string Description;

    public AchievementInfo(string name, string description)
    {
        Name = name;
        Description = description;
    }
}

public static class AchievementText
{
    public static readonly Dictionary<Achievement, AchievementInfo> Info = new Dictionary<Achievement, AchievementInfo>()
    {
        // Score milestones
        { Achievement.First10Points, new AchievementInfo("First 10 Points", "First 10 points! You're on your way!") },
        { Achievement.First25Points, new AchievementInfo("25 Points", "25 points scored! Keep going!") },
        { Achievement.First50Points, new AchievementInfo("50 Points", "50 points! Math superstar!") },
        { Achievement.First100Points, new AchievementInfo("100 Points", "100 points! Amazing!") },
        { Achievement.Score200Points, new AchievementInfo("200 Points", "200 points! You rock!") },
        { Achievement.Score500Points, new AchievementInfo("500 Points", "500 points! Math legend!") },

        // Addition & Subtraction only
        { Achievement.FirstCorrectAddSub, new AchievementInfo("First Add/Sub Correct", "First addition/subtraction correct! Bravo!") },
        { Achievement.FiveCorrectAddSubInRow, new AchievementInfo("5 Add/Sub in a Row", "5 in a row! Addition/subtraction master!") },
        { Achievement.TenCorrectAddSubInRow, new AchievementInfo("10 Add/Sub in a Row", "10 in a row! Incredible!") },
        { Achievement.TwentyPointsAddSub, new AchievementInfo("20 Points Add/Sub", "20 points using add/sub! Keep it up!") },
        { Achievement.FiftyEquationsAddSub, new AchievementInfo("50 Add/Sub Solved", "Solved 50 add/sub equations! Genius!") },

        // Multiplication & Division only
        { Achievement.FirstCorrectMulDiv, new AchievementInfo("First Mul/Div Correct", "First multiplication/division correct! Well done!") },
        { Achievement.ThreeCorrectMulDivInRow, new AchievementInfo("3 Mul/Div in a Row", "3 in a row! Multiplication/division wizard!") },
        { Achievement.FiveCorrectMulDivInRow, new AchievementInfo("5 Mul/Div in a Row", "5 in a row! Amazing!") },
        { Achievement.TwentyPointsMulDiv, new AchievementInfo("20 Points Mul/Div", "20 points using mul/div! Fantastic!") },
        { Achievement.FiftyEquationsMulDiv, new AchievementInfo("50 Mul/Div Solved", "Solved 50 mul/div equations! Incredible!") },

        // Combo achievements
        { Achievement.ThreeCorrectInRow, new AchievementInfo("3 Correct in a Row", "3 correct in a row! Nice streak!") },
        { Achievement.FiveCorrectInRow, new AchievementInfo("5 Correct in a Row", "5 correct in a row! Keep going!") },
        { Achievement.TenCorrectInRow, new AchievementInfo("10 Correct in a Row", "10 correct in a row! You're unstoppable!") },
        { Achievement.TwentyCorrectInRow, new AchievementInfo("20 Correct in a Row", "20 correct in a row! Math champ!") },
        { Achievement.FiftyCorrectInRow, new AchievementInfo("50 Correct in a Row", "50 correct in a row! Legendary!") },

        // Specific number achievements
        { Achievement.DivisionDividend10xDivisor, new AchievementInfo("Big Division", "Division hero! Managed a big one!") },
        { Achievement.SubtractionResultZero, new AchievementInfo("Zeroed Out", "Zeroed it out! Great subtraction!") },
        { Achievement.MaxNumberSolved, new AchievementInfo("Max Number", "Reached the max number! Well done!") },
        { Achievement.MinNumberSolved, new AchievementInfo("Min Number", "Hit the minimum! Nice work!") },

        // Power-up achievements
        { Achievement.FirstPowerUpCollected, new AchievementInfo("First Power-Up", "First power-up collected! Power up!") },
        { Achievement.ShieldUsedSuccessfully, new AchievementInfo("Shield Master", "Shield used successfully! Safe and sound!") },
        { Achievement.SurvivedSpeedBoost, new AchievementInfo("Speed Survivor", "Survived a speed boost! Fast and furious!") },

        // Fun / Miscellaneous
        { Achievement.FirstIncorrectAnswer, new AchievementInfo("Oops!", "Oops! First mistake – learning is fun!") },
        { Achievement.TenGatesWithoutHitting, new AchievementInfo("Perfect Run", "Perfect run! 10 gates without hitting!") }
    };
}
