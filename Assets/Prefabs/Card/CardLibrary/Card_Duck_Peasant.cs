#region AUTO-GENERATED
// Do not manually change code within the AUTO-GENERATED region. Instead update the Card Library spreadsheet and run npm build-cards
public class Duck_Peasant_Properties
{
  public static int __id__ = 2;
	public static string __title__ = "Duck Peasant";
	public static string __description__ = "This is the poorest kind of duck";
	public static string __image__ = "https://via.placeholder.com/150";
	public static int __woodCost__ = 1;
	public static int __stoneCost__ = 1;
}
  
public class Card_Duck_Peasant : Card_Unit
{
  public Card_Duck_Peasant() : base(
    Duck_Peasant_Properties.__id__,
		Duck_Peasant_Properties.__title__,
		Duck_Peasant_Properties.__description__,
		Duck_Peasant_Properties.__image__,
		Duck_Peasant_Properties.__woodCost__,
		Duck_Peasant_Properties.__stoneCost__
  )
  { }

  #endregion AUTO-GENERATED
  
  public override void Play()
  {
    // TODO: Add logic
  }
}