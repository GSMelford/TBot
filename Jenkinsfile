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
                    sh "cd /var/lib/jenkins/workspace/TBot/"
                    echo "=== building ==="
                    sh "sudo dotnet --version"
                    sh "sudo dotnet build"
                }
            }
        }
        stage("Pack TBot") {
            steps {
                echo "=== packing ==="
                sh "sudo dotnet pack --output nupkgs"
            }
        }
        stage("Publich TBot") {
            steps {
                echo "=== publishing ==="
                sh "sudo dotnet nuget push \"./nupkgs/*.nupkg\" --api-key $NUGET_KEY --source https://api.nuget.org/v3/index.json --skip-duplicate"
            }
        }
    }
}