#region AUTO-GENERATED
// Do not manually change code within the AUTO-GENERATED region. Instead update the Card Library spreadsheet and run npm build-cards
public class Stone_Properties
{
  public static int __id__ = 1;
	public static string __title__ = "Stone";
	public static string __description__ = "This is some stone";
	public static string __image__ = "https://via.placeholder.com/150";
	public static int __woodCost__ = 0;
	public static int __stoneCost__ = 0;
}
  
public class Card_Stone : Card_Resource
{
  public Card_Stone() : base(
    Stone_Properties.__id__,
		Stone_Properties.__title__,
		Stone_Properties.__description__,
		Stone_Properties.__image__,
		Stone_Properties.__woodCost__,
		Stone_Properties.__stoneCost__
  )
  { }

  #endregion AUTO-GENERATED
  
  public override void Play()
  {
    // TODO: Add logic
  }
}