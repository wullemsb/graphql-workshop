using System.Collections.Generic;
using ConferencePlanner.GraphQL.Common;
using ConferencePlanner.GraphQL.Data;

namespace ConferencePlanner.GraphQL.Tracks
{
    public class RenameTrackPayload : TrackPayloadBase
    {
        public RenameTrackPayload(Track track) 
            : base(track)
        {
        }

        public RenameTrackPayload(UserError error)
            : base(new[] { error })
        {
        }

        public RenameTrackPayload(IReadOnlyList<UserError> errors) 
            : base(errors)
        {
        }
    }
}