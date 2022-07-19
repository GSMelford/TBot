#!groovy

pipeline {
    agent any
    options {
        timestamps()
        disableConcurrentBuilds()
    }

    stages {
        stage("Build TBot") {
            steps {
                script {
                    echo "=== building ==="
                    sh "/usr/share/dotnet/dotnet --version"
                    sh "/usr/share/dotnet/dotnet build"
                }
            }
        }
        stage("Pack TBot") {
            steps {
                echo "=== packing ==="
                sh "/usr/share/dotnet/dotnet pack --output nupkgs"
            }
        }
        stage("Publich TBot") {
            steps {
                echo "=== publishing ==="
                sh "/usr/share/dotnet/dotnet nuget push \"./nupkgs/*.nupkg\" --api-key $NUGET_KEY --source https://api.nuget.org/v3/index.json --skip-duplicate"
            }
        }
    }
}