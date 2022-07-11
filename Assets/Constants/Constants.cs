public class Constants
{
    // SCENES
    public static readonly string MENU_SCENE = "Menu";
    public static readonly string GAME_SCENE = "Game";
    public static readonly string LOSE_SCENE = "Lose";

    // GAME OBJECTS
    public static readonly string CANVAS_OBJECT = "Canvas";
    public static readonly string CREWMATE_OBJECT = "Crewmate";
    public static readonly string SKIN_OBJECT = "Skin";
    public static readonly string PLAYER_OBJECT = "Player";
    public static readonly string EXPLOSION_OBJECT = "Explosion";

    // PREFABS
    public static readonly string BOSS_PREFAB = "Boss(Clone)";
    public static readonly string ENEMY_PREFAB = "Enemy(Clone)";
    public static readonly string QUESTION_PREFAB = "Question(Clone)";

    // TAGS
    public static readonly string PLAYER_TAG = "Player";
    public static readonly string ENEMY_TAG = "Enemy";
    public static readonly string MISSILE_TAG = "Missile";

    // OVERLAYS
    public static readonly string MENU_BUTTON_OVERLAY = "MenuButton";
    public static readonly string SCORE_OVERLAY = "Score";
    public static readonly string ANSWER_ONE_OVERLAY = "A1Text";
    public static readonly string ANSWER_TWO_OVERLAY = "A2Text";
    public static readonly string ANSWER_THREE_OVERLAY = "A3Text";

    // SPRITE NAMES
    public static readonly string[] SPRITES =
    {
        "Sprites/CrewmateBlack",
        "Sprites/CrewmateBlue",
        "Sprites/CrewmateBrown",
        "Sprites/CrewmateCyan",
        "Sprites/CrewmateGreen",
        "Sprites/CrewmateLime",
        "Sprites/CrewmateOrange",
        "Sprites/CrewmatePink",
        "Sprites/CrewmatePurple",
        "Sprites/CrewmateRed",
        "Sprites/CrewmateWhite",
        "Sprites/CrewmateYellow",
    };
    public static readonly string[] SKINS =
    {
        "Sprites/Skin0",
        "Sprites/Skin1",
        "Sprites/Skin2",
    };

    // PLAYER PREF KEYS
    public static readonly string SPRITE_SELECTED_KEY = "sprite_selected";
    public static readonly string SPRITE_OWNED_KEY = "sprite_owned";
    public static readonly string SPRITE_OWNED_MASK = "100000000000";
    public static readonly string SKIN_SELECTED_KEY = "skin_selected";
    public static readonly string SKIN_OWNED_KEY = "skin_owned";
    public static readonly string SKIN_OWNED_MASK = "100";

    // INVENTORY
    public static readonly string SCROLL_CONTENT_INVENTORY = "ScrollContent";
    public static readonly string SCROLL_VIEW_INVENTORY = "ScrollView";

    // SHOP
    public static readonly string BUY_BUTTON_SHOP = "BuyButton";
    public static readonly string BUY_TEXT_SHOP = "BuyText";

    // QUESTION GENERATION
    public static readonly string ADDITION = "+";
    public static readonly string SUBTRACTION = "−";
    public static readonly string MULTIPLICATION = "×";
    public static readonly string DIVISION = "÷";
    public static readonly string QUESTION_FORMAT = "{0} {1} {2} = ?";
}
