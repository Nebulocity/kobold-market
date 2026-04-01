# Kobold Market Domain Model

## Overview

Kobold Market is a hybrid tabletop campaign manager, miniature marketplace, hobby tracker, and build-sharing application.

The initial domain model is designed to support four core usage areas:

1. User identity and ownership
2. Campaign and character management
3. Session and loot tracking
4. Hobby and community features

---

## Core Entities

### User
Represents an account in the system.

A user can:
- create and manage characters
- own campaigns
- track miniature paint projects
- create marketplace listings
- share tabletop builds

### Character
Represents a tabletop character owned by a user.

A character can:
- belong to one user
- join multiple campaigns through CampaignMember
- receive loot during sessions

### Campaign
Represents a tabletop campaign owned by a user.

A campaign can:
- have many character members
- have many sessions
- store descriptive information like name, setting, and description

### CampaignMember
Represents the relationship between a campaign and a character.

This exists as an explicit join entity so metadata can be added later, such as:
- joined date
- role in campaign
- status
- notes

### Session
Represents a play session for a campaign.

A session belongs to one campaign and can contain many loot entries.

### LootEntry
Represents an item or reward earned during a session by a character.

A loot entry belongs to:
- one session
- one character

### PaintProject
Represents a miniature painting or hobby project owned by a user.

This supports progress tracking and hobby organization features.

### MarketplaceListing
Represents an item listed for sale by a user.

This supports the miniature marketplace side of the application.

### BuildShare
Represents a shared character build, campaign concept, or tabletop configuration created by a user.

This supports community sharing and discovery features.

---

## Relationship Summary

- User -> Characters: one-to-many
- User -> OwnedCampaigns: one-to-many
- User -> PaintProjects: one-to-many
- User -> MarketplaceListings: one-to-many
- User -> BuildShares: one-to-many

- Campaign -> CampaignMembers: one-to-many
- Character -> CampaignMemberships: one-to-many

- CampaignMember -> Campaign: many-to-one
- CampaignMember -> Character: many-to-one

- Campaign -> Sessions: one-to-many
- Session -> LootEntries: one-to-many
- Character -> LootEntries: one-to-many

---

## Design Notes

- This is just a fun idea I had for a portfolio project.