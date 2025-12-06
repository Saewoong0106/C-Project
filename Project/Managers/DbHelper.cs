using System;
using System.IO;

namespace Project.Managers
{
    // [조건: 클래스 사용] 데이터베이스 연결 정보 관리 전담 클래스
    public static class DBHelper
    {
        // [조건: 파일 처리/DB] SQLite DB 파일 경로 설정 (실행 프로그램 위치 기준)
        public static string ConnectionString = "Data Source=" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CafeStock.db");
    }
}