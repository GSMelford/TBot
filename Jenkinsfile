#!groovy

pipeline {
    agent any
    options {
        timestamps()
        disableConcurrentBuilds()
    }

    environment {
        TBOT_CORE_NAME = "TBot.Core"
        TBOT_CORE_VERSION = "0.1.2"
        TBOT_TELEGRAM_DTO_NAME = "TBot.Telegram.Dto"
        TBOT_TELEGRAM_DTO_VERSION = "0.1.2"
        TBOT_CLIENT_NAME = "TBot.Client"
        TBOT_CLIENT_VERSION = "0.2.5"
    }

    stages {
        stage("Build") {
            steps {
                script {
                    echo "=== building TBot ==="
                    sh "dotnet build"
                }
            }
        }
        stage("Pack TBot.Core") {
            steps {
                script {
                    echo "=== packing $TBOT_CORE_NAME ==="
                    sh "dotnet pack ./$TBOT_CORE_NAME/ -p:PackageVersion=$TBOT_CORE_VERSION --output ../nupkgs"
                    sh "dotnet nuget push ./nupkgs/$TBOT_CORE_NAME'.'$TBOT_CORE_VERSION -k $NUGET_KEY"
                }
            }
        }
        stage("Pack TBot.Telegram.Dto") {
            steps {
                script {
                    echo "=== packing $TBOT_CORE_NAME ==="
                    sh "dotnet pack ./$TBOT_CORE_NAME/ -p:PackageVersion=$TBOT_TELEGRAM_DTO_VERSION --output ../nupkgs"
                    sh "dotnet nuget push ./nupkgs/$TBOT_CORE_NAME'.'$TBOT_TELEGRAM_DTO_VERSION -k $NUGET_KEY"
                }
            }
        }
        stage("Pack TBot.Client") {
            steps {
                script {
                    echo "=== packing $TBOT_CLIENT_NAME ==="
                    sh "dotnet pack ./$TBOT_CLIENT_NAME/ -p:PackageVersion=$TBOT_CLIENT_VERSION --output ../nupkgs"
                    sh "dotnet nuget push ./nupkgs/$TBOT_CLIENT_NAME'.'$TBOT_CLIENT_VERSION -k $NUGET_KEY"
                }
            }
        }
    }
}