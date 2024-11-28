# Mongodb.Regression

The update of the driver to version 3.0.0 breaks code that uses dictionaries with boxing of values.
The driver version 2.30.0 still worked fine.

## How to execute

1. Run the docker container with the latest mongodb version. Update the password in the command:
`sudo docker run -p 27017:27017 --name local-mongoDbServer --restart=always -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=<your-password-here> -d mongo:latest`
2. Change the password in `Program.cs`
3. Now run the application and you will see that there are no errors
4. Open the csproj-file of `MongoDb.Regression` and replace the driver version to be 3.0.0 instead of 2.30.0
5. Rerun the application and you will see that it fails in L19 because it is missing the guid representation required by the boxed `Guid` value within the dictionary

```
An error occurred while serializing the Properties property of class MongoDb.Regression.Data: GuidSerializer cannot serialize a Guid when GuidRepresentation is Unspecified.
```