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
    public static readonly string HEALTHPOWERUP_TAG = "HpPowerup";

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
    public static readonly string SCORES_TOPSCORES = "TopScores";

    // INVENTORY
    public static readonly string SCROLL_CONTENT_INVENTORY = "ScrollContent";
    public static readonly string SCROLL_VIEW_INVENTORY = "ScrollView";

    // SHOP
    public static readonly string BUY_BUTTON_SHOP = "BuyButton";
    public static readonly string BUY_TEXT_SHOP = "BuyText";

    // GAME MODES
    public const int ORIGINAL_GAMEMODE = 0;
    public const int ADDITION_GAMEMODE = 1;
    public const int SUBTRACTION_GAMEMODE = 2;
    public const int MULTIPLICATION_GAMEMODE = 3;
    public const int DIVISION_GAMEMODE = 4;

    // QUESTION GENERATION
    public static readonly string ADDITION = "+";
    public static readonly string SUBTRACTION = "−";
    public static readonly string MULTIPLICATION = "×";
    public static readonly string DIVISION = "÷";
    public static readonly string QUESTION_FORMAT = "{0} {1} {2} = ?";
    
    // ATTACKS
    public const int VERTICAL_ATTACK = 1;
    public const int FAN_ATTACK = 2;
    public const int HOMING_ATTACK = 3;

    // SHOOT BEHAVIOUR
    public const int PAUSE_TO_SHOOT = 1;
    public const int SHOOT_AND_FLY = 2;

    // CUE CARDS
    public static readonly string CARD_SAVE_FILE = "/savedCueCards.gd";
    public static readonly string CARD_SCROLL_CONTENT = "CardScrollContent";
    public static readonly string CARD_SCROLL_VIEW = "CardScrollView";
    public static readonly string MAX_CARDS_MSG = "MAX {0} CUE CARDS!";
    public static readonly string EMPTY_FIELDS_MSG = "FIELDS CAN'T BE EMPTY!";
    public static readonly string CARD_ADDED_MSG = "CUE CARD ADDED!";
    public static readonly string CARD_OVERWRITTEN_MSG = "CUE CARD OVERWRITTEN!";
    public static readonly string CARD_QUESTION_INPUT = "QuestionInput";
    public static readonly string CARD_ANSWER_INPUT = "AnswerInput";
    public static readonly string CARD_ADD_PROMPT = "Prompt";
    public static readonly string CARD_TEXT_FORMAT = "Q: {0}\nA: {1}";
    public static readonly string CARDS_SCREEN = "CueCards";
    public const int MAX_CUE_CARDS = 100;
}
