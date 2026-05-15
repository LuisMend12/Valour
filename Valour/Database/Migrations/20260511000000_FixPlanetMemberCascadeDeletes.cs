using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Valour.Database.Migrations
{
    /// <inheritdoc />
    public partial class FixPlanetMemberCascadeDeletes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Change planet_member FK constraints from NO ACTION to CASCADE so that
            // deleting a planet_member removes all associated data rather than
            // leaving dangling rows or blocking deletion.

            migrationBuilder.Sql(@"
                DO $$ BEGIN
                    ALTER TABLE messages
                        DROP CONSTRAINT IF EXISTS ""FK_messages_planet_members_author_member_id"";
                    ALTER TABLE messages
                        ADD CONSTRAINT ""FK_messages_planet_members_author_member_id""
                        FOREIGN KEY (author_member_id) REFERENCES planet_members(id) ON DELETE CASCADE;
                EXCEPTION WHEN others THEN NULL; END $$;
            ");

            migrationBuilder.Sql(@"
                DO $$ BEGIN
                    ALTER TABLE message_reactions
                        DROP CONSTRAINT IF EXISTS ""FK_message_reactions_planet_members_author_member_id"";
                    ALTER TABLE message_reactions
                        ADD CONSTRAINT ""FK_message_reactions_planet_members_author_member_id""
                        FOREIGN KEY (author_member_id) REFERENCES planet_members(id) ON DELETE CASCADE;
                EXCEPTION WHEN others THEN NULL; END $$;
            ");

            migrationBuilder.Sql(@"
                DO $$ BEGIN
                    ALTER TABLE user_channel_states
                        DROP CONSTRAINT IF EXISTS ""FK_user_channel_states_planet_members_member_id"";
                    ALTER TABLE user_channel_states
                        ADD CONSTRAINT ""FK_user_channel_states_planet_members_member_id""
                        FOREIGN KEY (member_id) REFERENCES planet_members(id) ON DELETE CASCADE;
                EXCEPTION WHEN others THEN NULL; END $$;
            ");

            migrationBuilder.Sql(@"
                DO $$ BEGIN
                    ALTER TABLE eco_accounts
                        DROP CONSTRAINT IF EXISTS ""FK_eco_accounts_planet_members_planet_member_id"";
                    ALTER TABLE eco_accounts
                        ADD CONSTRAINT ""FK_eco_accounts_planet_members_planet_member_id""
                        FOREIGN KEY (planet_member_id) REFERENCES planet_members(id) ON DELETE CASCADE;
                EXCEPTION WHEN others THEN NULL; END $$;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DO $$ BEGIN
                    ALTER TABLE messages
                        DROP CONSTRAINT IF EXISTS ""FK_messages_planet_members_author_member_id"";
                    ALTER TABLE messages
                        ADD CONSTRAINT ""FK_messages_planet_members_author_member_id""
                        FOREIGN KEY (author_member_id) REFERENCES planet_members(id);
                EXCEPTION WHEN others THEN NULL; END $$;
            ");

            migrationBuilder.Sql(@"
                DO $$ BEGIN
                    ALTER TABLE message_reactions
                        DROP CONSTRAINT IF EXISTS ""FK_message_reactions_planet_members_author_member_id"";
                    ALTER TABLE message_reactions
                        ADD CONSTRAINT ""FK_message_reactions_planet_members_author_member_id""
                        FOREIGN KEY (author_member_id) REFERENCES planet_members(id);
                EXCEPTION WHEN others THEN NULL; END $$;
            ");

            migrationBuilder.Sql(@"
                DO $$ BEGIN
                    ALTER TABLE user_channel_states
                        DROP CONSTRAINT IF EXISTS ""FK_user_channel_states_planet_members_member_id"";
                    ALTER TABLE user_channel_states
                        ADD CONSTRAINT ""FK_user_channel_states_planet_members_member_id""
                        FOREIGN KEY (member_id) REFERENCES planet_members(id);
                EXCEPTION WHEN others THEN NULL; END $$;
            ");

            migrationBuilder.Sql(@"
                DO $$ BEGIN
                    ALTER TABLE eco_accounts
                        DROP CONSTRAINT IF EXISTS ""FK_eco_accounts_planet_members_planet_member_id"";
                    ALTER TABLE eco_accounts
                        ADD CONSTRAINT ""FK_eco_accounts_planet_members_planet_member_id""
                        FOREIGN KEY (planet_member_id) REFERENCES planet_members(id);
                EXCEPTION WHEN others THEN NULL; END $$;
            ");
        }
    }
}
