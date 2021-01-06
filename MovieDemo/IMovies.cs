using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MovieDemo
{
    /// <summary>
    /// Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MovieDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
    /// </summary>
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMovies" in both code and config file together.
    [ServiceContract]
    public interface IMovies
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        Movies_classcs GetMovie(int Id);
        [OperationContract]
        void SaveMovie(Movies_classcs movie);
    }
}
