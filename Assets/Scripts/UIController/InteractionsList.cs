using System.Runtime.Serialization;

public enum InteractionsList
{
    [EnumMember(Value = "01_introduction")] Intro,
    [EnumMember(Value = "02_on_observe")] DébutExperience,
    [EnumMember(Value = "03_voyager_en_groupe")] VolerEnsemble,
    [EnumMember(Value = "04_certains_oiseaux")] SeMettreEnV,
    [EnumMember(Value = "05_a_la_vue")] Piquer,
    [EnumMember(Value = "06_au_sein")] Rassembler,
    [EnumMember(Value = "07_comme_les_nuees")] Contemplation,
    [EnumMember(Value = "08_la_plupart")] VersGaucheDroite,
    [EnumMember(Value = "09_ces_courants")] VersCourant,
    [EnumMember(Value = "10_tous_les_poissons")] VersCourantSuite,
    [EnumMember(Value = "11_si_avancer")] EviterDêchetsPlastiques,
    [EnumMember(Value = "12_tous_les_predateurs")] Baitball,
    [EnumMember(Value = "13_la_plus_grosse")] Prédateur,
    [EnumMember(Value = "14_si_les_especes")] PrédateurSuite,
    [EnumMember(Value = "15_il_est")] FinExpérience,
    [EnumMember(Value = "16_la_nature")] ContemplationFinale,
}
