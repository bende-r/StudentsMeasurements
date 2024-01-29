namespace Students.Entities;

public class MeasurementOfStudent
{
    public DateTime DateOfMeasurement { get; set; }

    public string Level { get; set; }

    public string Gender { get; set; }

    public int LungCapacity { get; set; }

    public float Hand { get; set; }

    public int Height { get; set; }
    public float Weight { get; set; }

    public int BloodPressureBefore { get; set; }
    public int BloodPressureAfter { get; set; }

    public int HeartRateBefore { get; set; }
    public int HeartRateAfter { get; set; }

    public string HeartRateMin { get; set; }

    public MeasurementOfStudent(DateTime dateOfMeasurement, string gender, int lungCapacity, float hand, float weight, int height,
        int bloodPressureBefore, int bloodPressureAfter, int heartRateBefore, int heartRateAfter, string heartRateMin)
    {
        DateOfMeasurement = dateOfMeasurement;
        Gender = gender;
      
        LungCapacity = lungCapacity;
        Hand = hand;
        Weight = weight;
        Height = height;
        BloodPressureBefore = bloodPressureBefore;
        BloodPressureAfter = bloodPressureAfter;
        HeartRateBefore = heartRateBefore;
        HeartRateAfter = heartRateAfter;
        HeartRateMin = heartRateMin;

        CalcLevel();
    }

    public MeasurementOfStudent(){}

    public void CalcLevel()
    {
        int points = 0, WH, GM, SI, IR;

        WH = (int)(Weight * 1000 / Height);
        GM = (int)(LungCapacity / Weight);
        SI = (int)(Hand / Weight * 100);
        IR = (int)((BloodPressureBefore * HeartRateBefore) / 100);

        switch (Gender)
        {
            case "Жен":
                if (WH > 451)
                    points -= 2;
                if (WH >= 351 && WH <= 450)
                    points -= 1;

                if (GM <= 40)
                    points -= 1;
                if (GM >= 46 && GM <= 50)
                    points += 1;
                if (GM >= 51 && GM <= 56)
                    points += 2;
                if (GM > 56)
                    points += 3;

                if (SI <= 40)
                    points -= 1;
                if (SI >= 51 && SI <= 55)
                    points += 1;
                if (SI >= 56 && SI <= 60)
                    points += 2;
                if (SI > 61)
                    points += 3;

                if (IR >= 111)
                    points -= 2;
                if (IR <= 110 && IR >= 95)
                    points -= 1;
                if (IR <= 84 && IR >= 70)
                    points += 3;
                if (IR <= 69)
                    points += 5;

                if (HeartRateMin.Equals("Больше 3 минут"))
                    points -= 2;
                if (HeartRateMin.Equals("2-3 минуты"))
                    points += 1;
                if (HeartRateMin.Equals("1.5-2 минуты"))
                    points += 3;
                if (HeartRateMin.Equals("1-1.5 минуты"))
                    points += 5;
                if (HeartRateMin.Equals("Меньше минуты"))
                    points += 7;
                break;

            case "Муж":
                if (WH > 501)
                    points -= 2;
                if (WH >= 451 && WH <= 500)
                    points -= 1;

                if (GM <= 50)
                    points -= 1;
                if (GM >= 56 && GM <= 60)
                    points += 1;
                if (GM >= 61 && GM <= 65)
                    points += 2;
                if (GM > 66)
                    points += 3;

                if (SI <= 60)
                    points -= 1;
                if (SI >= 66 && SI <= 70)
                    points += 1;
                if (SI >= 71 && SI <= 80)
                    points += 2;
                if (SI > 81)
                    points += 3;

                if (IR >= 111)
                    points -= 2;
                if (IR <= 110 && IR >= 95)
                    points -= 1;
                if (IR <= 84 && IR >= 70)
                    points += 3;
                if (IR <= 69)
                    points += 5;

                if (HeartRateMin.Equals("Больше 3 минут") )
                    points -= 2;
                if (HeartRateMin.Equals("2-3 минуты"))
                    points += 1;
                if (HeartRateMin.Equals("1.5-2 минуты"))
                    points += 3;
                if (HeartRateMin.Equals("1-1.5 минуты"))
                    points += 5;
                if (HeartRateMin.Equals("Меньше минуты"))
                    points += 7;
                break;
        }

        if (points <= 4)
            Level = "Низкий";
        if (points >= 5 && points <= 9)
            Level = "Ниже среднего";
        if (points >= 10 && points <= 13)
            Level = "Средний";
        if (points >= 14 && points <= 16)
            Level = "Выше среднего";
        if (points >= 17)
            Level = "Высокий";
    }
}