using System;

namespace BizCodeFactory
{
    /// <summary>
    /// 表示一个规则信息
    /// </summary>
    [Serializable]
    public class RuleInfo
    {
        public int Id { get; set; }

        /// <summary>
        /// 租户Id
        /// </summary>
        public int? TenantId { get; set; }

        /// <summary>
        /// 规则名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 规则值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// 当前完整编码
        /// </summary>
        public string CurrentCode { get; set; }

        /// <summary>
        /// 当前序号
        /// </summary>
        public int CurrentNo { get; set; }

        /// <summary>
        /// 序号步长
        /// </summary>
        public int? NoStep { get; internal set; }

        /// <summary>
        /// 编码序号重置日期格式。（以当前时间为基准，如果当前时间不等于最后生成的时间，则重置编码）
        /// </summary>
        public string ResetDateFormat { get; set; }

        /// <summary>
        /// 最后生成编码时间
        /// </summary>
        public DateTime? LastFactoryDate { get; set; }

        #region Audited

        DateTime CreationTime { get; set; }
        long? CreatorUserId { get; set; }

        DateTime? DeletionTime { get; set; }
        long? DeleterUserId { get; set; }

        DateTime? LastModificationTime { get; set; }
        long? LastModifierUserId { get; set; }
        #endregion

        /// <inheritdoc />
        public RuleInfo()
        {
        }

        /// <inheritdoc />
        public RuleInfo(
            int id,
            int? tenantId,
            string name,
            string value,
            string currentCode,
            int currentNo,
            int? noStep = null,
            bool isEnabled = true)
        {
            Id = id;
            TenantId = tenantId;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Value = value ?? throw new ArgumentNullException(nameof(value));
            CurrentCode = currentCode ?? throw new ArgumentNullException(nameof(currentCode));
            CurrentNo = currentNo;
            NoStep = noStep;
            IsEnabled = isEnabled;
        }
    }
}