#region AUTO-GENERATED
// Do not manually change code within the AUTO-GENERATED region. Instead update the Card Library spreadsheet and run npm build-cards
public class Breathe_Fire_Properties
{
  public static int __id__ = 4;
	public static string __title__ = "Breathe Fire";
	public static string __description__ = "Allows the duck to breathe fire. Is this safe?";
	public static string __image__ = "https://via.placeholder.com/150";
	public static int __woodCost__ = 2;
	public static int __stoneCost__ = 0;
}
  
public class Card_Breathe_Fire : Card_Spell
{
  public Card_Breathe_Fire() : base(
    Breathe_Fire_Properties.__id__,
		Breathe_Fire_Properties.__title__,
		Breathe_Fire_Properties.__description__,
		Breathe_Fire_Properties.__image__,
		Breathe_Fire_Properties.__woodCost__,
		Breathe_Fire_Properties.__stoneCost__
  )
  { }

  #endregion AUTO-GENERATED

  public override void Play()
  {
    // TODO: Add logic
  }
}