using System.Speech.Synthesis;
using Attribute.Common.Annotations;

namespace Attribute.Speech.Synthesis
{
    /// <summary>
    ///     An interface for the speaker class.
    /// </summary>
    public interface ISpeaker
    {
        #region [-- PUBLIC & PROTECTED METHODS --]

        /// <summary>
        ///     Speaks the specified line.
        /// </summary>
        /// <param name="line">The line to speak.</param>
        /// <param name="synthesizer">The optional synthesizer to use when speaking.</param>
        void Speak([NotNull] string line, SpeechSynthesizer synthesizer = null);

        /// <summary>
        ///     Speaks the specified line asynchronously.
        /// </summary>
        /// <param name="line">The line to speak.</param>
        /// <param name="synthesizer">The optional synthesizer to use when speaking.</param>
        void SpeakAsync(string line, SpeechSynthesizer synthesizer = null);

        /// <summary>
        /// Stops the speaker from speaking.
        /// </summary>
        void Stop();

        #endregion


        #region [-- PROPERTIES --]

        /// <summary>
        ///     Gets or sets the name of the <see cref="ISpeaker" />.
        /// </summary>
        /// <value>
        ///     The name of the <see cref="ISpeaker" />.
        /// </value>
        string SpeakerName { get; set; }

        /// <summary>
        /// Gets or sets the synthesizer.
        /// </summary>
        /// <value>
        /// The synthesizer.
        /// </value>
        SpeechSynthesizer Synthesizer { get; set; }

        /// <summary>
        ///     Gets or sets the name of the voice to use when this <see cref="ISpeaker" /> speaks.
        /// </summary>
        /// <value>
        ///     The <see cref="ISpeaker" /> voice name.
        /// </value>
        string VoiceName { get; set; }

        #endregion
    }
}
