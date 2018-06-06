
namespace Global.Core
{
    public enum InstanceTypes
    {
        // These values must exactly match tblSubject->SubjectType
        Language,
        Location,
        Subsite,
        SubsiteCreate,
        SubsiteBatch,
        Collection,
        CollectionItem,
        Reference,
        Template,
        Block,
        Folder,
        Document,
        UserMatch,      // This is special item for matching user 
        User,
        MainMenu,
        SetupMenu,
    }
}
