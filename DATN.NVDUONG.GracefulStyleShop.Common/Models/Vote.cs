using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.NVDUONG.GracefulStyleShop.Common.Models
{
    public class Vote
    {
        public Guid VoteId { get; set; }
        public int StarNumber { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid ProductId { get; set; }
        public Vote()
        {

        }
        public Vote(Guid voteId, int starNumber, Guid productId)
        {
            this.VoteId = voteId;
            this.StarNumber = starNumber;
            this.ProductId  = productId;
        }
        public Vote(Guid voteId, int starNumber, string comment, DateTime createdAt, Guid productId)
        {
            VoteId = voteId;
            StarNumber = starNumber;
            Comment = comment;
            CreatedAt = createdAt;
            ProductId = productId;
        }
    }
}
