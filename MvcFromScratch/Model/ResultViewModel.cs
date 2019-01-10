using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcFromScratch.Model {
    public class ResultViewModel {

        public int Result { get; private set; }

        public ResultViewModel(int result) {
            Result = result;
        }
    }
}
