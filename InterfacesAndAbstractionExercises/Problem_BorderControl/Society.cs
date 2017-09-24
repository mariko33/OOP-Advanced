public abstract class Society
{
    private string name;
    private string id;

    protected Society(string name, string id)
    {
        this.name = name;
        this.id = id;
    }

    public bool Isdetained(string fakeId)
    {
        return this.id.EndsWith(fakeId);
    }

    public string FakeId()
    {
        return this.id;
    }
}
