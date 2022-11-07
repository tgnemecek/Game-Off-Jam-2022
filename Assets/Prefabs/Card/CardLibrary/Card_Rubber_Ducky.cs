#region AUTO-GENERATED
// Do not manually change code within the AUTO-GENERATED region. Instead update the Card Library spreadsheet and run npm build-cards
public class Rubber_Ducky_Properties
{
  public static int __id__ = 3;
	public static string __title__ = "Rubber Ducky";
	public static string __description__ = "This is actually a lifelike representation of the most famous duck war hero";
	public static string __image__ = "https://via.placeholder.com/150";
	public static int __woodCost__ = 1;
	public static int __stoneCost__ = 1;
}
  
public class Card_Rubber_Ducky : Card_Item
{
  public Card_Rubber_Ducky() : base(
    Rubber_Ducky_Properties.__id__,
		Rubber_Ducky_Properties.__title__,
		Rubber_Ducky_Properties.__description__,
		Rubber_Ducky_Properties.__image__,
		Rubber_Ducky_Properties.__woodCost__,
		Rubber_Ducky_Properties.__stoneCost__
  )
  { }

  #endregion AUTO-GENERATED
  
  public override void Play()
  {
    // TODO: Add logic
  }
}