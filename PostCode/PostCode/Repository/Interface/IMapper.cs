namespace PostCode.Repository
{
    public interface IMapper<Def, My>
        where Def : class
        where My : class
    {
        Def GetForAppUser(My entity);
        My GetForUser(Def entity);
    }
}
