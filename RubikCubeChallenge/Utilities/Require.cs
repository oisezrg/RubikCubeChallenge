namespace RubikCubeChallenge.Utilities
{
    internal static class Require
    {
        public static void NotNull(object o, string name)
        {
            if (o == null)
            {
                throw new ArgumentNullException(string.Format("Require not null: {0}", name));
            }
        }

        public static void Equals(object o, object v, string name)
        {
            if (!o.Equals(v))
            {
                throw new ArgumentException(string.Format("Require equal {0} == {1}", o, v));
            }
        }
    }
}
