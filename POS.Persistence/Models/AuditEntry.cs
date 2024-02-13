using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace POS.Persistence.Models
{
    public enum AuditType
    {
        None = 0,
        Create = 1,
        Update = 2,
        Delete = 3
    }
    public class AuditEntry
    {
        public AuditEntry(EntityEntry entry)
        {
            Entry = entry;
        }
        public EntityEntry Entry { get; }
        public string UserId { get; set; }
        public string TableName { get; set; }
        public Dictionary<string, object> KeyValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();
        public AuditType AuditType { get; set; }
        public List<string> ChangedColumns { get; } = new List<string>();
        public AuditLogs ToAudit()
        {
            var _AuditLogs = new AuditLogs();
            _AuditLogs.UserId = UserId;
            _AuditLogs.Type = AuditType.ToString();
            _AuditLogs.TableName = TableName;
            _AuditLogs.DateTime = DateTime.UtcNow;
            _AuditLogs.PrimaryKey = JsonConvert.SerializeObject(KeyValues);
            _AuditLogs.OldValues = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues);
            _AuditLogs.NewValues = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues);
            _AuditLogs.AffectedColumns = ChangedColumns.Count == 0 ? null : JsonConvert.SerializeObject(ChangedColumns);
            return _AuditLogs;
        }
    }
}
