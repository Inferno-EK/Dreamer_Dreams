class CreatorClasses 
{
    string Name;
    string Description;
    int ClassW;
    Restriction restriction;
    string waySprite;


    public CreatorClasses(string _Name, string _Description, string _ClassW, Restriction _restriction, string _waySprite)
    {
        Name = _Name;
        Description = _Description;
        
        switch (_ClassW)
        {
            case "Melee":
                ClassW = (int)Enums.WeapunClasses.Melee;
                break;
            case "Ranged":
                ClassW = (int)Enums.WeapunClasses.Ranged;
                break;
            case "Magic":
                ClassW = (int)Enums.WeapunClasses.Magic;
                break;
            case "Summon":
                ClassW = (int)Enums.WeapunClasses.Summon;
                break;

            default:
                ClassW = 5;
                break;
        }
        

        restriction = _restriction;
        waySprite = _waySprite;
    }
}
