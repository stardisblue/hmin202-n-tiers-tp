using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using share;

namespace share
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IServiceRecette
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        List<Recette> searchRecette(Ingredient ingr);

        [OperationContract]
        string deletecourante(string nom);

        [OperationContract]
        Recette createRecette(string nom);

        [OperationContract]
        string saveRecette(Recette recette);

        [OperationContract]
        string addRecette(Recette recette);

        [OperationContract]
        Recette getRecette(string Nom);

        [OperationContract]
        Ingredient newIngredient(string nom);

        [OperationContract]
        string addIngredient(string Recette, string Ingredient);

        [OperationContract]
        Ingredient getIngredient(string Nom);

        [OperationContract]
        bool isEmpty();

        [OperationContract]
        List<Recette> getInfoCourante();

        [OperationContract]
        Dictionary<string, Recette> listeBase();
    }

    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IBase
    {
        [OperationContract]
        Dictionary<string, Recette> basedelaRecettes();

    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations

    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
