using System.Threading;
using System.Threading.Tasks;
using ConferencePlanner.GraphQL.Common;
using ConferencePlanner.GraphQL.Data;
using ConferencePlanner.GraphQL.Sessions;
using HotChocolate;
using HotChocolate.Types;

namespace ConferencePlanner.GraphQL.Tracks
{
    [ExtendObjectType(HotChocolate.Language.OperationType.Mutation)]
    public class TrackMutations
    {
        public async Task<AddTrackPayload> AddTrackAsync(
            AddTrackInput input,
            ApplicationDbContext context,
            CancellationToken cancellationToken)
        {
            var track = new Track { Name = input.Name };
            context.Tracks.Add(track);

            await context.SaveChangesAsync(cancellationToken);

            return new AddTrackPayload(track);
        }

        public async Task<RenameTrackPayload> RenameTrackAsync(
            RenameTrackInput input,
            ApplicationDbContext context,
            CancellationToken cancellationToken)
        {
            Track? track = await context.Tracks.FindAsync(input.Id);
            if (track is null)
                return new RenameTrackPayload(
                   new UserError("Track not found.", "TRACK_NOT_FOUND"));

            track.Name = input.Name;

            await context.SaveChangesAsync(cancellationToken);

            return new RenameTrackPayload(track);
        }
    }
}