using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemModel.TO
{
    /// <summary>
    /// TO przechowujący parametry poziomu dostępu.
    /// </summary>
    public class PrivilegeTO
    {
        /// <summary>
        /// Identyfikator poziomu uprawnień.
        /// </summary>
        public int? PrivilegeId { get; set; }

        /// <summary>
        /// Nazwa przywileju. Do zastosowania w UI.
        /// </summary>
        public string PrivilegeName { get; set; }

        /// <summary>
        /// Opis przywileju. Do zastosowania w UI.
        /// </summary>
        public string PrivilegeDesc { get; set; }

        /// <summary>
        /// Poziom uprawnień dla tego przywileju.
        /// </summary>
        public int? PrivilegeLevel { get; set; }
    }
}
