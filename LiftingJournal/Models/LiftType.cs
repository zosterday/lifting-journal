using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LiftingJournal.Models
{
    public enum LiftType
    {
        //Only adding "important" exercises that I actually would care to track

        //Chest
        [Display(Name = "Bench Press")]
        BenchPress,
        [Display(Name = "Larson Press")]
        LarsonPress,
        [Display(Name = "dumbbell Press")]
        dumbbellPress,
        [Display(Name = "Incline dumbbell Press")]
        InclinedumbbellPress,
        [Display(Name = "Incline Bench Press")]
        InclineBenchPress,
        [Display(Name = "Weighted Dip")]
        WeightedDip,
        [Display(Name = "Unweighted Dip")]
        Dip,
        [Display(Name = "Pec Deck")]
        PecDeck,
        //Back
        [Display(Name = "Weighted Chin Up")]
        WeightedChinUp,
        [Display(Name = "Wide Grip Weighted Pull Up")]
        WideGripWeightedPullUp,
        [Display(Name = "Neutral Grip Weighted Pull Up")]
        NeutralGripWeightedPullUp,
        [Display(Name = "Laying Chest Supported Row")]
        LayingChestSupportedRow,
        [Display(Name = "Barbell Row")]
        BarbellRow,
        [Display(Name = "Single Arm dumbbell Row")]
        SingleArmDumbbellRo,
        [Display(Name = "Seated Cable Rows")]
        SeatedCableRow,
        [Display(Name = "Unweighted Pull Up")]
        PullUp,
        [Display(Name = "Cabled Pull Down")]
        CablePullDown,
        [Display(Name = "Hyperextension")]
        HyperExtension,
        //Bis
        [Display(Name = "Preacher Curl")]
        PreacherCurl,
        [Display(Name = "Dumbbell Curl")]
        DumbbellCurl,
        [Display(Name = "Hammer Curl")]
        HammerCurl,
        [Display(Name = "Supinated Across the Chest Curl")]
        SupinatedAcrossTheChestCurl,
        [Display(Name = "Incline Dumbbell Curl")]
        InclineDumbbellCurl,
        [Display(Name = "Barbell Curl")]
        BarbellCurl,
        //Tris
        [Display(Name = "Close Grip Bench")]
        CloseGripBench,
        [Display(Name = "Ez Bar Pushdown")]
        EzBarPushDown,
        [Display(Name = "Rope Pushdown")]
        RopePushDown,
        [Display(Name = "Overhead Cable Extension")]
        OverheadCableExtension,
        [Display(Name = "Single Arm Cable Pushdown")]
        SingleArmCablePushdown,
        //Shoulders
        [Display(Name = "Overhead Press")]
        OverheadPress,
        [Display(Name = "Dumbbell Shoulder Press")]
        DumbbellShoulderPress,
        [Display(Name = "Lateral Raise")]
        LateralRaise,
        [Display(Name = "Rear Delt Dumbbell Fly")]
        RearDeltDumbbellFly,
        [Display(Name = "Reverse Pec Deck")]
        ReversePecDeck,
        [Display(Name = "Handstand Push Up")]
        HandstandPushUp,
        [Display(Name = "Maltese Pull")]
        MaltesePull,
        //Legs
        [Display(Name = "Squat")]
        Squat,
        [Display(Name = "Deadlift")]
        Deadlift,
        [Display(Name = "Hack Squat")]
        HackSquat,
        [Display(Name = "Seated Hamstring Curl")]
        SeatedHamstringCurl,
        [Display(Name = "Leg Extension")]
        LegExtension,
        [Display(Name = "Calf Raise")]
        CalfRaise,
    }
}

