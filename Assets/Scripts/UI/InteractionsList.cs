using System.Runtime.Serialization;

public enum InteractionsList
{
    [EnumMember(Value = "00_default")] Default,
    [EnumMember(Value = "01_introduction")] Intro, //38s
    [EnumMember(Value = "02_on_observe")] VolerEnsemble,//23s
    [EnumMember(Value = "03_voyager_en_groupe")] SeMettreEnV,//32s
    [EnumMember(Value = "04_certains_oiseaux")] WatchBirds,//33s
    [EnumMember(Value = "05_a_la_vue")] Piquer,//07s
    [EnumMember(Value = "06_au_sein")] Rassembler,//22s
    [EnumMember(Value = "07_comme_les_nuees")] Contemplation,//48s
    [EnumMember(Value = "08_la_plupart")] VersGaucheDroite,//27s
    [EnumMember(Value = "09_ces_courants")] VersCourant,//58s
    [EnumMember(Value = "10_tous_les_poissons")] VersCourantSuite,//27s
    [EnumMember(Value = "11_si_avancer")] EviterDêchetsPlastiques,//1.03s
    [EnumMember(Value = "12_tous_les_predateurs")] Baitball,//37s
    [EnumMember(Value = "13_la_plus_grosse")] Prédateur,//43s
    [EnumMember(Value = "14_si_les_especes")] PrédateurSuite,//16s
    [EnumMember(Value = "15_il_est")] FinExpérience,//27s
    [EnumMember(Value = "16_la_nature")] ContemplationFinale,//38s
}