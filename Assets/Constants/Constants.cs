public class Constants
{
    // SCENES
    public static readonly string MENU_SCENE = "Menu";
    public static readonly string GAME_SCENE = "Game";
    public static readonly string LOSE_SCENE = "Lose";
    public static readonly string WARNING_SCENE = "Warning";

    // GAME OBJECTS
    public static readonly string CANVAS_OBJECT = "Canvas";
    public static readonly string CREWMATE_OBJECT = "Crewmate";
    public static readonly string SKIN_OBJECT = "Skin";
    public static readonly string PLAYER_OBJECT = "Player";
    public static readonly string CARD_ANSWER_TEXT_OBJECT = "AnswerText";
    public static readonly string BREAK_MESSAGE_OBJECT = "BreakMessage";

    // PREFABS
    public static readonly string BOSS_PREFAB = "Boss(Clone)";
    public static readonly string ENEMY_PREFAB = "Enemy(Clone)";
    public static readonly string MATH_QUESTION_PREFAB = "MathQuestion(Clone)";
    public static readonly string CUE_CARD_QUESTION_PREFAB = "CueCardQuestion(Clone)";

    // TAGS
    public static readonly string PLAYER_TAG = "Player";
    public static readonly string ENEMY_TAG = "Enemy";
    public static readonly string MISSILE_TAG = "Missile";
    public static readonly string HEALTHPOWERUP_TAG = "HpPowerup";
    public static readonly string NUKEPOWERUP_TAG = "NukePowerup";
    public static readonly string NUKEBUTTON_TAG = "NukeButton";

    // OVERLAYS
    public static readonly string PAUSE_BUTTON_OVERLAY = "PauseButton";
    public static readonly string SCORE_OVERLAY = "Score";

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
    public static readonly string SCORES_BALANCE = "balance";

    // INVENTORY
    public static readonly string SCROLL_CONTENT_INVENTORY = "ScrollContent";
    public static readonly string SCROLL_VIEW_INVENTORY = "ScrollView";
    public static readonly string UNLOCKS_AT_INVENTORY = "UNLOCKS AT ";
    public static readonly int[] HIGHSCORE_THRESHOLDS =
    {
        0,
        10,
        20,
        30,
        40,
        50,
        60,
        70,
        80,
        90,
        100,
        200,
    };
    public static readonly string[] CREWMATES_INVENTORY =
    {
        "Crewmate (0)",
        "Crewmate (1)",
        "Crewmate (2)",
        "Crewmate (3)",
        "Crewmate (4)",
        "Crewmate (5)",
        "Crewmate (6)",
        "Crewmate (7)",
        "Crewmate (8)",
        "Crewmate (9)",
        "Crewmate (10)",
        "Crewmate (11)",
    };
    public static readonly string[] TEXT_INVENTORY =
    {
        "Text (0)",
        "Text (1)",
        "Text (2)",
        "Text (3)",
        "Text (4)",
        "Text (5)",
        "Text (6)",
        "Text (7)",
        "Text (8)",
        "Text (9)",
        "Text (10)",
        "Text (11)",
    };

    // SHOP
    public static readonly string BUY_BUTTON_SHOP = "BuyButton";
    public static readonly string BUY_TEXT_SHOP = "BuyText";
    public static readonly string BALANCE_TEXT_SHOP = "BalanceText";
    public static readonly string BALANCE_TEXT_PREFIX = "BALANCE: $";
    public static readonly int[] PRICES =
    {
        0,
        10,
        10,
    };

    public static readonly string SCORES_TEXT = "HighScores";

    public static readonly string CONFIRMATION_TEXT = "Confirmation";
    public static readonly string CONFIRMATION_DATA = "DATA HAS BEEN RESET";

    // GAME MODES
    public const int ORIGINAL_GAMEMODE = 0;
    public const int ADDITION_GAMEMODE = 1;
    public const int SUBTRACTION_GAMEMODE = 2;
    public const int MULTIPLICATION_GAMEMODE = 3;
    public const int DIVISION_GAMEMODE = 4;
    public const int CUE_CARDS_GAMEMODE = 5;

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
    public const int CIRCLE_ATTACK = 4;
    public const int SPIRAL_ATTACK = 5;
    public const int RANDOM_ATTACK = 6;
    public const int VERTICAL_AND_HOMING_ATTACK = 7;
    public const int FAN_AND_HOMING_ATTACK = 8;
    public const int CIRCLE_AND_HOMING_ATTACK = 9;
    public const int SPIRAL_AND_HOMING_ATTACK = 10;
    public const int RANDOM_AND_HOMING_ATTACK = 11;
    public const int NO_ATTACK = 100;

    // SHOOT BEHAVIOUR
    public const int PAUSE_TO_SHOOT = 1;
    public const int SHOOT_AND_FLY = 2;

    // GAME OBJECT MESSAGES
    public static readonly string EMPTY_AMMO = "EmptyAmmo";
    public static readonly string SET_PARAMETERS = "SetParameters";

    // CUE CARD CREATOR
    public static readonly string CARD_SAVE_FILE = "/savedCueCards.gd";
    public static readonly string MAX_CARDS_MSG = "MAX {0} CUE CARDS!";
    public static readonly string EMPTY_FIELDS_MSG = "FIELDS CAN'T BE EMPTY!";
    public static readonly string CARD_ADDED_MSG = "CUE CARD ADDED!";
    public static readonly string CARD_OVERWRITTEN_MSG = "CUE CARD OVERWRITTEN!";
    public static readonly string NO_CARDS_MSG = "MUST HAVE AT LEAST ONE CUE CARD TO PLAY!";
    public static readonly string CARD_TEXT_FORMAT = "Q: {0}\nA: {1}";
    public static readonly string CARDS_SCREEN = "CueCards";
    public const int MAX_CUE_CARDS = 100;

    // BREAK TIME
    public static readonly string BREAK_MESSAGE_TEXT = "You've been playing for {0} minutes!\nConsider taking a break, the bots will always be here for you to defeat!";
}
