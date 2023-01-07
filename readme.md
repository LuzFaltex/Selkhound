# Selkhound

Selkhound is an open source, community-based chat app combinining the best features of Discord and Matrix.

Our design goals include:

* Open User API, allowing for users to use the default client applicaiton or to roll their own.
* Federated user instances. Use the public Selkhound instance or spin up your own.
  * Docker and Kubernetes support is planned.
* End to End Encryption with perfect forward secrecy.
* Role-based Access Control.
* Extensible through plugin API to allow for third party integrations, such as OAuth.
* Documented and version controlled API using SEMVER.

# Projects

Selkhound.API - Provides default concrete types for the API. Also used by the internal API.
Selkhound.API.Abstractions - Provides abstractions for the Selkhound API.
Selkhound.Server - The base server runtime with the REST API.