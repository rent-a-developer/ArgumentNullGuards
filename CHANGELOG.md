# Change Log
All notable changes to this project will be documented in this file.
 
The format is based on [Keep a Changelog](http://keepachangelog.com/) and
this project adheres to [Semantic Versioning](http://semver.org/).

## [1.1.0] - 2026-01-28

### Changed
- Switched to NullabilityInfoContext to determine nullability of parameters.
- For types not in a nullable enabled context, ArgumentNullGuardVerifier now assumes reference types are non-nullable
instead of throwing a NoNullableEnabledContextException.

## [1.0.1] - 2025-12-30

### Fixed
- Fixed icon URL in README.md.
 
## [1.0.0] - 2025-12-30
- Initial release.
