using System.Media;
using System.Reflection;

namespace Attribute.Common.Attributes
{
    /// <summary>
    ///     Attribute for type members that should reference a specific <see cref="SystemSound" />.  The name of the sound is
    ///     passed in the attribute definition.
    /// </summary>
    public sealed class SystemSoundAttribute : System.Attribute
    {
        #region [-- CONSTRUCTORS --]

        /// <summary>
        ///     Creates a new <see cref="SystemSoundAttribute" />.  <see cref="soundName" /> represents the
        ///     <see cref="SystemSounds" /> property name of the <see cref="SystemSound" />.
        /// </summary>
        /// <param name="soundName">The <see cref="SystemSounds" /> property name of the desired <see cref="SystemSound" />.</param>
        public SystemSoundAttribute(string soundName)
        {
            this._soundName = soundName;
        }

        #endregion


        #region [-- PROPERTIES --]

        /// <summary>
        ///     The <see cref="SystemSound" /> that this attribute represents.  Obtained from <see cref="SystemSounds" />.
        /// </summary>
        public SystemSound Sound
        {
            get
            {
                var property = typeof(SystemSounds).GetProperty(
                                                                this._soundName,
                                                                BindingFlags.Default | BindingFlags.Public
                                                                | BindingFlags.Static);
                var invoke = property?.GetGetMethod().Invoke(null, null);
                return invoke as SystemSound;
            }
        }

        #endregion


        #region [-- FIELDS --]

        private readonly string _soundName;

        #endregion
    }
}
