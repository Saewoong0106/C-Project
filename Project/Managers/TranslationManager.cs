using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization; // 참조 추가 필요 (없으면 생략하고 아래 설명 참고)
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Project.Managers
{
    // [선택 조건: OpenAPI 활용] 구글 번역 API 연동 클래스
    public static class TranslationManager
    {
        // 구글 번역 (무료 버전 엔드포인트)
        private static readonly string BaseUrl = "https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}";

        // 번역 요청 함수 (비동기)
        // sourceLang: 원본 언어 (kr), targetLang: 목표 언어 (en, ja)
        public static async Task<string> TranslateAsync(string text, string targetLang)
        {
            if (targetLang == "ko") return text; // 한국어면 번역 안 함

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // URL 만들기 (한글은 URL 인코딩 필요)
                    string url = string.Format(BaseUrl, "ko", targetLang, Uri.EscapeDataString(text));

                    // 구글 서버에 요청 보내기
                    string result = await client.GetStringAsync(url);

                    // 결과 파싱 (JSON 형태: [[["Hello","안녕하세요",...]]])
                    // 간단하게 앞부분만 잘라서 추출
                    int index = result.IndexOf("\"");
                    int nextIndex = result.IndexOf("\"", index + 1);
                    string translatedText = result.Substring(index + 1, nextIndex - index - 1);

                    return translatedText;
                }
            }
            catch
            {
                return text; // 에러 나면 원래 글자 반환
            }
        }
    }
}