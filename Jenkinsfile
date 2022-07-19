#!groovy

pipeline {
    agent any
    options {
        timestamps()
        disableConcurrentBuilds()
    }

    environment {
        TBOT_CORE_NAME = "TBot.Core"
        TBOT_CORE_VERSION = "0.1.3"
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
                    sh "/usr/share/dotnet/dotnet --version"
                    sh "/usr/share/dotnet/dotnet build"
                }
            }
        }
        stage("Pack TBot") {
            steps {
                echo "=== packing $TBOT_CORE_NAME ==="
                sh "/usr/share/dotnet/dotnet pack --output nupkgs"
            }
        }
    }
}