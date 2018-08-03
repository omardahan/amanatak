using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmanatakBLL.Models
{

    
     public class Item : BaseEntity
    {
       
        [Key]
        public int Id { get; set; }

        [DataType(DataType.MultilineText)]
        public string SerialNumber { get; set; }
        [Required(ErrorMessage = "حقل إجباري")]
         
        public int ItemTypeId { get; set; }
        [ForeignKey("ItemTypeId")]
        public virtual ItemType ItemType { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "حقل إجباري")]

        public string ItemDetails { get; set; }
        public UserType UserType { get; set; }
        public ItemCategory ItemCategory { get; set; }

        
        public string   AdressFound { get; set; }



        //for prototyp
        public int UserId { get; set; }
        public bool  ItemView { get; set; } //View by operator
        public bool Deliveried { get; set; }

        public virtual ICollection<ItemImages> ItemImages { get; set; }



   

        
 
    }
    public class ItemImages : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }
        public int ItemId { get; set; }

      

        public string ImagePath { get; set; }
    }
    public class ItemType : BaseEntity
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool Status { get; set; }
        }

    public class Conversation :BaseEntity
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int UserId { get; set; }
   
        public ICollection<ConversationMessages> ConversationMessages { get; set; }
     }
    public class ConversationMessages:BaseEntity
    {
        public int Id { get; set; }
        public int ConversationId { get; set; }

        [ForeignKey("ConversationId")]
        public virtual Conversation Conversation { get; set; }
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
        public UserType UserType { get; set; }
    }
    public class Country : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class IdentificationType : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ItemOwner : BaseEntity
    {

        public int Id { get; set; }

        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }
        public int ItemId { get; set; }
               
        public string FirstName { get; set; }
                
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }


   

        public bool? Gender { get; set; }

        public int NationalityId { get; set; }
        [ForeignKey("NationalityId")]
        public virtual Country Nationality { get; set; }
        public int? IdentificationID { get; set; }
        [ForeignKey("IdentificationID")]
        public virtual IdentificationType Identification { get; set; }
        public string IdentificationNo { get; set; }


        public string Mobile { get; set; }
        [DataType(DataType.EmailAddress)]
               
        public string Email { get; set; }
        public string Address { get; set; }
        public bool EmailConfirm { get; set; }




    }

 
    public class ItemsHistory : BaseEntity
    {
        public int Id { get; set; }
        public int ItemId { get; set; }

        public int? ItemMissingId { get; set; }

        public DateTime DeliveryTime { get; set; }
        public string DeliveryNamePerson { get; set; }
        [DataType(DataType.MultilineText)]

        public string Details { get; set; }

        public int UserId { get; set; }
    }


    //Type of Action on history for exp. Delivered , BackToOwner
    public enum ItemCategory
    {
        Found = 1,
        Missing = 2
    }

    public enum UserType
    {
        Operator = 1,
        Guest = 2
    }
    

}


