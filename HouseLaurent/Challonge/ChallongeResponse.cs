using System;
using System.Collections.Generic;
using System.Net;

namespace HouseLaurent.Challonge
{
    /// <summary>
    /// The response from a call to a Challonge API. A <see cref="IChallongeContext"/> may also mimic such a response if it resolves the call locally.
    /// </summary>
    internal class ChallongeResponse
    {
        /// <summary>
        /// If <see cref="HttpStatusCode.OK"/>, success. Otherwise, failure.
        /// </summary>
        public HttpStatusCode Code { get; }

        /// <summary>
        /// A list of human-friendly error strings.
        /// </summary>
        public IReadOnlyList<string> Errors { get; }

        public ChallongeResponse(HttpStatusCode code, IReadOnlyList<string> errors)
        {
            Code = code;
            Errors = errors;
        }

        protected ChallongeResponse()
        {
            Code = HttpStatusCode.OK;
            Errors = Array.Empty<string>();
        }

        public static ChallongeResponse OK => new ChallongeResponse();
    }

    /// <summary>
    /// A <see cref="ChallongeResponse"/> with a generic value.
    /// </summary>
    internal class ChallongeResponse<TValue> : ChallongeResponse
    {
        /// <summary>
        /// If <see cref="ChallongeResponse.Code"/> is <see cref="HttpStatusCode.OK"/>, some meaningful value. Otherwise, null or some garbage value.
        /// </summary>
        public TValue Value { get; }

        public ChallongeResponse(HttpStatusCode code, IReadOnlyList<string> errors, TValue value) : base(code, errors)
        {
            Value = value;
        }

        public ChallongeResponse(TValue value) : base()
        {
            Value = value;
        }

        public static implicit operator ChallongeResponse<TValue>(TValue value) => new ChallongeResponse<TValue>(value);
    }
}
