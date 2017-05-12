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
        bool containsIngredient(String nameIngredient);

        [OperationContract]
        List<Recette> rechercheParNomIngredient(String nom);

        [OperationContract]
        Recette newRecette(String nom);

        [OperationContract]
        Ingredient newIngredient(String nom);

        [OperationContract]
        List<Recette> searchRecette(Ingredient ingr);

        [OperationContract]
        String getNomIngre(Ingredient ing);

        [OperationContract]
        String getNomRecette(Recette rec);

        [OperationContract]
        String deletecourante(String nom);

        [OperationContract]
        String addRecette(Recette recette);

        [OperationContract]
        Boolean isEmpty();

        [OperationContract]
        List<Recette> getInfoCourante();

        [OperationContract]
        void initializebase();

        [OperationContract]
        List<Recette> listeBase();
      
    }

    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IBase
    {
        [OperationContract]
        List<Recette> basedelaRecettes();

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
