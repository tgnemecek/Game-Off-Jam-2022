#region AUTO-GENERATED
// Do not manually change code within the AUTO-GENERATED region. Instead update the Card Library spreadsheet and run npm build-cards
public class Rubber_Ducky_Factory_Properties
{
  public static int __id__ = 5;
	public static string __title__ = "Rubber Ducky Factory";
	public static string __description__ = "Mass produces Rubber Duckies to promote Duckland nationalism";
	public static string __image__ = "https://via.placeholder.com/150";
	public static int __woodCost__ = 10;
	public static int __stoneCost__ = 10;
}
  
public class Card_Rubber_Ducky_Factory : Card_Building
{
  public Card_Rubber_Ducky_Factory() : base(
    Rubber_Ducky_Factory_Properties.__id__,
		Rubber_Ducky_Factory_Properties.__title__,
		Rubber_Ducky_Factory_Properties.__description__,
		Rubber_Ducky_Factory_Properties.__image__,
		Rubber_Ducky_Factory_Properties.__woodCost__,
		Rubber_Ducky_Factory_Properties.__stoneCost__
  )
  { }

  #endregion AUTO-GENERATED
  
  public override void Play()
  {
    // TODO: Add logic
  }
}