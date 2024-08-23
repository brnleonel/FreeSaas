namespace FreeSaas.Domain.Interfaces
{
    public abstract class Entity
    {
        /*
        int? _requestedHashCode;
        Int32 _Id;

        public virtual Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;

                OnIdChanged();
            }
        }
        */

        protected virtual void OnIdChanged()
        {

        }

        /*
        public bool IsTransient()
        {
            return this.Id == 0;
        }
        */

        /*
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
                return false;

            if (Object.ReferenceEquals(this, obj))
                return true;

            Entity item = (Entity)obj;

            if (item.IsTransient() || this.IsTransient())
                return false;
            else
                return item.Id == this.Id;
        }
        */

        public override int GetHashCode()
        {
            /*
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = this.Id.GetHashCode() ^ 31;

                return _requestedHashCode.Value;
            }
            else
                */
                return base.GetHashCode();
        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }
    }
}
