Pangul .net core implementation
===============================


# How to deploy

In order to deploy the Pangul on [Fandogh](https://fandogh.cloud), the docker image should first be pushed into a docker registry.
To keep it simple for now we assume image is supposed to be published in fandogh docker registry.

* First of all we need to initialize the image repository. 
<b>This step needs to be done only once for</b>
```bash
fandogh image init --name pangul-netcore
```

* Once the new version is ready to be published, run the following command:
```bash
fandogh image publish --version ${THE_VERSION_YOU_WANT_TO_PUBLISH}
```

* Last step is (re)deploying the service
```bash
fandogh service apply -f fandogh-manifest.yml --IMAGE_VERSION=${THE_VERSION_YOU_JUST_PUBLISHED}
```



