using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USGData
{
  public  class FileType:_FileType
    {
        /// <summary>
		/// Instantiates an empty instance of the ClientUploadNote class.
		/// </summary>
		public FileType() : base()
        {
        }

        /// <summary>
        /// Instantiates a filled instance of the ClientUploadNote class.
        /// </summary>
        public FileType(Int32 _FileTypeID) : base(_FileTypeID)
        {
        }
    }
}
