#region AUTO-GENERATED
// Do not manually change code within the AUTO-GENERATED region. Instead update the Card Library spreadsheet and run npm build-cards
public class Wood_Properties
{
  public static int __id__ = 0;
	public static string __title__ = "Wood";
	public static string __description__ = "This is some wood";
	public static string __image__ = "https://via.placeholder.com/150";
	public static int __woodCost__ = 0;
	public static int __stoneCost__ = 0;
}
  
public class Card_Wood : Card_Resource
{
  public Card_Wood() : base(
    Wood_Properties.__id__,
		Wood_Properties.__title__,
		Wood_Properties.__description__,
		Wood_Properties.__image__,
		Wood_Properties.__woodCost__,
		Wood_Properties.__stoneCost__
  )
  { }

  #endregion AUTO-GENERATED
  
  public override void Play()
  {
    // TODO: Add logic
  }
}