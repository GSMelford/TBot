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
                    sh "sudo /var/lib/jenkins/workspace/TBot/dotnet --version"
                    sh "sudo dotnet build"
                }
            }
        }
        stage("Pack TBot") {
            steps {
                echo "=== packing ==="
                sh "sudo /var/lib/jenkins/workspace/TBot/dotnet pack --output nupkgs"
            }
        }
        stage("Publich TBot") {
            steps {
                echo "=== publishing ==="
                sh "sudo /var/lib/jenkins/workspace/TBot/dotnet nuget push \"./nupkgs/*.nupkg\" --api-key $NUGET_KEY --source https://api.nuget.org/v3/index.json --skip-duplicate"
            }
        }
    }
}