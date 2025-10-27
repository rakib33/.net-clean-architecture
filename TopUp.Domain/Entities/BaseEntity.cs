namespace TopUp.Domain.Entities;

//add common properties to this class that you want to be inherited by all entities in the domain layer.
public abstract class BaseEntity<T>
{
    public T? Id { get; set; }
    public long? CreatedBy { get; set; }   
    public DateTime? CreatedDate { get; set; }
    public long? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public bool? IsRemoved { get; set; } = false;
}

//donot add properties/fields/methods to this class. Do that in the above class.
public abstract class BaseEntity : BaseEntity<int> { }
